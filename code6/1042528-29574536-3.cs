    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNet.Facebook;
    using Microsoft.AspNet.Facebook.Client;
    using System.Threading.Tasks;
     public class FacebookHelper
    {
        public static async Task<IList<T>> GetArrayAsync<T>(Facebook.FacebookClient facebookClient, string path)
        {
            dynamic response = await facebookClient.GetTaskAsync(path);
            var str = response.ToString() as string;
            if (str.IsNullOfEmpty())
                return default(IList<T>);
            var result = await Newtonsoft.Json.JsonConvert.DeserializeObjectAsync<FbData<T>>(str);
            return result.Data;
        }
        public static async Task<bool> EnsureRequiredPermissions(Facebook.FacebookClient facebookClient, params string[] Permissions)
        {
            var requiredPermissions = new List<String>(Permissions);
            var userPerms = await GetArrayAsync<UserPermission>(facebookClient, "me/permissions");
            var allowed = from e in userPerms where e.Granted select e.Permission;
            requiredPermissions.RemoveAll(o => allowed.Contains(o));
            return requiredPermissions.Count == 0;
        }
    }
