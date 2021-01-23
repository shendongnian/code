    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;
    
    namespace OurUsers
    {
    class SyncAD
    {
        #region Variables
    
        private string sDomain = "sw.main.company.com";
        private string sDomainGC = "sw.main.company.com:3268";
        private string sDefaultOU = "DC=sw,DC=main,DC=company,DC=com";
        private string sDefaultRootOU = "DC=main,DC=company,DC=com";
        private string sGroupName = "Production_Universal_AD_Group";
        private string connectionString = "Server=OurServerName\\PROD; Integrated Security=True; Initial Catalog=OurUsers";
        private string sqlAdd = "SELECT FullID FROM ViewFolkstoAdd";
        private string sqlRemove = "SELECT FullID FROM ViewFolkstoRemove";
    
        #endregion
        public void SyncADUsers()
        {
            // Get Database Ready and Remove Users
            SqlConnection connectionRemove = new SqlConnection(connectionString);
            SqlCommand commandRemove = new SqlCommand(sqlRemove, connectionRemove);
            connectionRemove.Open();
            SqlDataReader readerRemove = commandRemove.ExecuteReader();
    
            if (readerRemove.HasRows)
            {
                int i = 0;
                while (readerRemove.Read())
                {
                    string sUserName = readerRemove.GetString(0);
                    RemoveUserFromGroup(sUserName, sGroupName);
                    i = i + 1;
                    Console.WriteLine("{0} {1}", i, sUserName);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            readerRemove.Close();
            
            // Get Database Ready and Add Users
            SqlConnection connectionAdd = new SqlConnection(connectionString);
            SqlCommand commandAdd = new SqlCommand(sqlAdd, connectionAdd);
            connectionAdd.Open();
            SqlDataReader readerAdd = commandAdd.ExecuteReader();
    
            if (readerAdd.HasRows)
            {
                int i = 0;
                while (readerAdd.Read())
                {
                    string sUserName = readerAdd.GetString(0);
                    AddUserToGroup(sUserName, sGroupName);
                    i = i + 1;
                    Console.WriteLine("{0} {1}", i, sUserName);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            readerAdd.Close();
        }
    
        /// Gets a certain user on Active Directory
        /// Returns the UserPrincipal Object
        public UserPrincipal GetUser(string sUserName)
        {
            PrincipalContext oPrincipalContext = GetPrincipalContextGC();
            UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, sUserName);
            return oUserPrincipal;
        }
    
        /// Adds the user for a given group
        /// Returns true if successful
        public bool AddUserToGroup(string sUserName, string sGroupName)
        {
            try
            {
                UserPrincipal oUserPrincipal = GetUser(sUserName);
                GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);
                if (oUserPrincipal != null && oGroupPrincipal != null)
                {
                    oGroupPrincipal.Members.Add(oUserPrincipal);
                    oGroupPrincipal.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    
        /// Removes user from a given group
        /// Returns true if successful
        public bool RemoveUserFromGroup(string sUserName, string sGroupName)
        {
            try
            {
                UserPrincipal oUserPrincipal = GetUser(sUserName);
                GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);
                if (oUserPrincipal != null && oGroupPrincipal != null)
                {
                    oGroupPrincipal.Members.Remove(oUserPrincipal);
                    oGroupPrincipal.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    
        /// Gets PrincipalContext from the Local Domain
        /// Returns the PrincipalContext
        public PrincipalContext GetPrincipalContext()
        {
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, sDomain, sDefaultOU, ContextOptions.Negotiate);
            return oPrincipalContext;
        }
    
        /// Gets PrincipalContext from the Global Catalog
        /// Returns the PrincipalContext
        public PrincipalContext GetPrincipalContextGC()
        {
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, sDomainGC, sDefaultRootOU, ContextOptions.Negotiate);
            return oPrincipalContext;
        }
    
        /// Gets a certain group on Active Directory
        /// Returns the GroupPrincipal Object
        public GroupPrincipal GetGroup(string sGroupName)
        {
            PrincipalContext oPrincipalContext = GetPrincipalContext();
            GroupPrincipal oGroupPrincipal = GroupPrincipal.FindByIdentity(oPrincipalContext, sGroupName);
            return oGroupPrincipal;
        }
    }
    }
