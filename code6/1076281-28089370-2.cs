    private void UpdateUsers()
    {
        //Create mapping of old guid to new guid.
        Dictionary<Guid, Guid> LookupRoleGuids = new Dictionary<Guid, Guid>();
        //Add guid mapping
        LookupRoleGuids.Add(new Guid(Old Guid), new Guid(New Guid));
            
        QueryExpression query = new QueryExpression();
        query.EntityName = "systemuser";
        query.ColumnSet = new AllColumns();
        ConditionExpression ce2 = new ConditionExpression();
        ce2.AttributeName = "systemuserid";
        ce2.Operator = ConditionOperator.Equal;
        ce2.Values = new string[] { User Id }; //Can alter to retrieve for a BU
        FilterExpression filter = new FilterExpression();
        filter.Conditions = new ConditionExpression[] { ce2 };
        query.Criteria = filter;
        try
        {
            BusinessEntityCollection UserCollection = crmService.RetrieveMultiple(query);
                
            //store the roles of the Users.
            StoreUserRoles(UserCollection);
            foreach (BusinessEntity be in UserCollection.BusinessEntities)
            {
                //Update users BU.
                Guid newBu = new Guid(New BU Guid);
                systemuser su = (systemuser)be;
                SetBusinessSystemUserRequest setBUreq = new SetBusinessSystemUserRequest();
                setBUreq.BusinessId = newBu;
                setBUreq.UserId = su.systemuserid.Value;
                SecurityPrincipal assignee = new SecurityPrincipal();
                assignee.PrincipalId = new Guid(su.systemuserid.Value.ToString());
                setBUreq.ReassignPrincipal = assignee;
                SetBusinessSystemUserResponse assigned = (SetBusinessSystemUserResponse)crmService.Execute(setBUreq);
                //Get users existing roles
                if (UserRolesList.Count() > 0)
                {
                    UserRoles ur = UserRolesList.Where(x => x.Value == su.systemuserid.Value)
                                                .Select(x => x).First();
                    //Get new role guids based on mapping
                    Guid[] roleguids = LookupRoleGuids.Where(x => ur.Roles.Contains(x.Key))
                                                      .Select(x => x.Value)
                                                      .ToArray();
                    //Assign new roles 
                    AssignUserRolesRoleRequest addRoles = new AssignUserRolesRoleRequest();
                    addRoles.UserId = su.systemuserid.Value;
                    addRoles.RoleIds = roleguids;
                    crmService.Execute(addRoles);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred updating users BU or assigning new roles. Error: " + ex.Message);
        }
    }
    public void StoreUserRoles(BusinessEntityCollection UserRolesCollection)
    {
        UserRolesList = new List<UserRoles>(); 
        foreach (BusinessEntity be in UserRolesCollection.BusinessEntities)
        {
            systemuser u = (systemuser)be;
            UserRoles ur = new UserRoles();
            ur.Username = u.domainname;
            ur.Value = u.systemuserid.Value;
            UserRolesList.Add(ur);
        }
        AddRolesToList(ref UserRolesList);
    }
    private void AddRolesToList(ref List<UserRoles> URList)
    {
        //Get all roles for a given user guid
        QueryExpression query = new QueryExpression();
        query.EntityName = "role";
        ColumnSet cols = new ColumnSet();
        cols.Attributes = new string[] { "roleid" };
        query.ColumnSet = cols;
        LinkEntity le = new LinkEntity();
        le.LinkFromEntityName = "role";
        le.LinkToEntityName = "systemuserroles";
        le.LinkFromAttributeName = "roleid";
        le.LinkToAttributeName = "roleid";
        LinkEntity le2 = new LinkEntity();
        le2.LinkFromEntityName = "systemuserroles";
        le2.LinkToEntityName = "systemuser";
        le2.LinkFromAttributeName = "systemuserid";
        le2.LinkToAttributeName = "systemuserid";
        foreach(UserRoles ur in URList)
        {
            //loop through the list of userroles and alter the conditional expression with the user's guid.
            ConditionExpression ce = new ConditionExpression();
            ce.AttributeName = "systemuserid";
            ce.Operator = ConditionOperator.Equal;
            ce.Values = new string[] { ur.Value.ToString() };
            le2.LinkCriteria = new FilterExpression();
            le2.LinkCriteria.Conditions = new ConditionExpression[] { ce };
            le.LinkEntities = new LinkEntity[] { le2 };
            query.LinkEntities = new LinkEntity[] { le };
            try
            {
                BusinessEntityCollection RoleGuidsCollection = crmService.RetrieveMultiple(query);
                foreach (BusinessEntity be in RoleGuidsCollection.BusinessEntities)
                {
                    role r = (role)be;
                    ur.Roles.Add(r.roleid.Value);
                }
            }
            catch (SoapException se)
            {
                throw new Exception("Error occurred retrieving Role Ids for " + ur.Username + " (" + ur.Value + "). " + se.Detail.InnerXml);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred retrieving Role Guids for " + ur.Username + " (" + ur.Value + "). " + ex.Message);
            }
        }
    }
