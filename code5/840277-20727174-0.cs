    using System.Web.Security;
    using System.Configuration.Provider;
    using System;
    using System.Linq;
    /*
     
     This provider works with the following schema for the tables of role data.
     
    CREATE TABLE [tblRoles] (
     [Rolename]        NVARCHAR (255) NOT NULL,
     [ApplicationName] NVARCHAR (255) NOT NULL,
     CONSTRAINT [PKRoles] PRIMARY KEY
     CLUSTERED ([Rolename] ASC, [ApplicationName] ASC)
    );
 
    CREATE TABLE [tblUsersInRoles] (
    [Username]        NVARCHAR (255) NOT NULL,
    [Rolename]        NVARCHAR (255) NOT NULL,
    [ApplicationName] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PKUsersInRoles] PRIMARY KEY 
    CLUSTERED ([Username] ASC, [Rolename] ASC, [ApplicationName] ASC)
    ); 
     
    */
    namespace mvc2.Models
    {
      public class CustomRoleProvider : RoleProvider
      {
        private string pApplicationName = "MyApplicationName";
        Database1Entities db; //ADO.NET Entity Data Mode(Entity Framework 6.0)
        public override string ApplicationName
        {
            get { return pApplicationName; }
            set { pApplicationName = value; }
        }
        public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
        {
            db = new Database1Entities();
            if (!RoleExists(rolename))
            {
                throw new ProviderException("Role does not exist.");
            }
            if (throwOnPopulatedRole && GetUsersInRole(rolename).Length > 0)
            {
                throw new ProviderException("Cannot delete a populated role.");
            }
            var resultRoles = db.tblRoles.Where(x => x.Rolename == rolename &&
                x.ApplicationName == ApplicationName);
            db.tblRoles.RemoveRange(resultRoles);
            var resultUserInRoles = db.tblUsersInRoles.Where(x => x.Rolename == rolename &&
               x.ApplicationName == ApplicationName);
            db.tblUsersInRoles.RemoveRange(resultUserInRoles);
            db.SaveChanges();
            return true;
        }
        public override string[] GetAllRoles()
        {
            db = new Database1Entities();
            return db.tblRoles.Where(x => x.ApplicationName == ApplicationName)
                .Select(x => x.Rolename).ToArray();
        }
        public override string[] GetUsersInRole(string rolename)
        {
            db = new Database1Entities();
            return db.tblUsersInRoles.Where(x => x.Rolename == rolename &&
                x.ApplicationName == ApplicationName).Select(x => x.Username).ToArray();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames)
        {
            foreach (string rolename in rolenames)
            {
                if (!RoleExists(rolename))
                {
                    throw new ProviderException("Role name not found.");
                }
            }
            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    if (!IsUserInRole(username, rolename))
                    {
                        throw new ProviderException("User is not in role.");
                    }
                }
            }
            db = new Database1Entities();
            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    tblUsersInRole result = db.tblUsersInRoles.Where(x =>
                        x.Username == username &&
                        x.Rolename == rolename &&
                        x.ApplicationName == ApplicationName).FirstOrDefault();
                    if (result != null)
                    {
                        db.tblUsersInRoles.Remove(result);
                    }
                }
            }
            db.SaveChanges();
        }
        public override string[] FindUsersInRole(string rolename, string usernameToMatch)
        {
            db = new Database1Entities();
            return db.tblUsersInRoles.Where(x =>
                x.Username == usernameToMatch &&
                x.Rolename == rolename &&
                x.ApplicationName == ApplicationName
                ).Select(x => x.Username).ToArray();
        }
        public override bool RoleExists(string rolename)
        {
            Database1Entities db = new Database1Entities();
            bool exists = db.tblRoles.Where(x => x.Rolename == rolename &&
                x.ApplicationName == ApplicationName).Count() > 0 ? true : false;
            return exists;
        }
        public override void AddUsersToRoles(string[] usernames, string[] rolenames)
        {
            db = new Database1Entities();
            int RoleCheck = rolenames.Where(x => RoleExists(x)).Count();
            if (RoleCheck == 0)
            {
                throw new ProviderException("Role name not found.");
            }
            int CheckCommasInUsername = usernames.Where(x => x.ToString().Contains(",")).Count();
            if (CheckCommasInUsername > 0)
            {
                throw new ArgumentException("User names cannot contain commas.");
            }
            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    if (IsUserInRole(username, rolename))
                    {
                        throw new ProviderException("User is already in role.");
                    }
                }
            }
            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    tblUsersInRole newRecord = new tblUsersInRole();
                    newRecord.Username = username;
                    newRecord.Rolename = rolename;
                    newRecord.ApplicationName = ApplicationName;
                    db.tblUsersInRoles.Add(newRecord);                    
                }
            }
            db.SaveChanges();
           
        }
        public override void CreateRole(string rolename)
        {
            if (rolename.Contains(","))
            {
                throw new ArgumentException("Role names cannot contain commas.");
            }
            if (RoleExists(rolename))
            {
                throw new ProviderException("Role name already exists.");
            }
            db = new Database1Entities();
            tblRole newRole = new tblRole();
            newRole.Rolename = rolename;
            newRole.ApplicationName = ApplicationName;
            db.tblRoles.Add(newRole);
            db.SaveChanges();
        }
        public override string[] GetRolesForUser(string username)
        {
            db = new Database1Entities();
            return db.tblUsersInRoles.Where(x => x.Username == username &&
                x.ApplicationName == ApplicationName).Select(x => x.Rolename).ToArray();
        }
        public override bool IsUserInRole(string username, string rolename)
        {
            db = new Database1Entities();
            return db.tblUsersInRoles.Where(x =>
                x.Username == username &&
                x.Rolename == rolename &&
                x.ApplicationName == ApplicationName).Count() > 0 ? true : false;
        }
      }
    }
