    var assignToCaseOwner = new_entity.Attributes["new_assigntocaseowner"];
       if ((bool)assignToCaseOwner)
           {             
                activityEntity.Attributes.Add("ownerid", sourceCaseAttributes.Attributes["ownerid"]);
            }
