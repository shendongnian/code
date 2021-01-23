    using System;
    using System.Net;
    using JSIStudios.SimpleRESTServices.Client;
    using net.openstack.Core.Domain;
    using net.openstack.Core.Request;
    using net.openstack.Core.Response;
    namespace net.openstack.Core.Providers
    {
        public class ExtendedOpenStackIdentityProvider : OpenStackIdentityProvider
        {
            public ExtendedOpenStackIdentityProvider(Uri urlBase)
                : base(urlBase)
            {
            }
            public ExtendedOpenStackIdentityProvider(Uri urlBase, CloudIdentity identity)
                : base(urlBase, identity)
            {
            }
            public ExtendedOpenStackIdentityProvider(Uri urlBase, JSIStudios.SimpleRESTServices.Client.IRestService restService, net.openstack.Core.Caching.ICache<UserAccess> tokenCache)
                : base(urlBase, restService, tokenCache)
            {
            }
            public ExtendedOpenStackIdentityProvider(Uri urlBase, CloudIdentity identity, JSIStudios.SimpleRESTServices.Client.IRestService restService, net.openstack.Core.Caching.ICache<UserAccess> tokenCache)
                : base(urlBase, identity, restService, tokenCache)
            {
            }
            public NewTenant AddTenant(NewTenant tenant, CloudIdentity identity)
            {
                if (tenant == null)
                    throw new ArgumentNullException("tenant");
                if (string.IsNullOrEmpty(tenant.Name))
                    throw new ArgumentException("tenant.Name cannot be null or empty");
                if (tenant.Id != null)
                    throw new InvalidOperationException("tenant.Id must be null");
                CheckIdentity(identity);
                var response = ExecuteRESTRequest<NewTenantResponse>(identity, new Uri(UrlBase, "/v2.0/tenants"), HttpMethod.POST, new AddTenantRequest(tenant));
                if (response == null || response.Data == null)
                    return null;
                return response.Data.NewTenant;
            }
            public Tenant GetTenant(string tenantId, CloudIdentity identity)
            {
                if (tenantId == null)
                    throw new ArgumentNullException("tenantId");
                CheckIdentity(identity);
                var urlPath = string.Format("v2.0/tenants/{0}", tenantId);
                var response = ExecuteRESTRequest<TenantResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.GET);
                if (response == null || response.Data == null)
                    return null;
                return response.Data.Tenant;
            }
            public bool DeleteTenant(string tenantId, CloudIdentity identity)
            {
                if (tenantId == null)
                    throw new ArgumentNullException("tenantId");
                if (string.IsNullOrEmpty(tenantId))
                    throw new ArgumentException("tenantId cannot be empty");
                CheckIdentity(identity);
                var urlPath = string.Format("v2.0/tenants/{0}", tenantId);
                var response = ExecuteRESTRequest(identity, new Uri(UrlBase, urlPath), HttpMethod.DELETE);
                if (response != null && response.StatusCode == HttpStatusCode.NoContent)
                    return true;
                return false;
            }
            public bool AddTenantUserRole(string tenantId, string userId, string roleId, CloudIdentity identity)
            {
                if (tenantId == null)
                    throw new ArgumentNullException("tenantId");
                if (string.IsNullOrEmpty(tenantId))
                    throw new ArgumentException("tenantId cannot be empty");
                if (userId == null)
                    throw new ArgumentNullException("userId");
                if (string.IsNullOrEmpty(userId))
                    throw new ArgumentException("userId cannot be empty");
                if (roleId == null)
                    throw new ArgumentNullException("roleId");
                if (string.IsNullOrEmpty(roleId))
                    throw new ArgumentException("roleId cannot be empty");
                CheckIdentity(identity);
                var urlPath = string.Format("v2.0/tenants/{0}/users/{1}/roles/OS-KSADM/{2}", tenantId, userId, roleId);
                var response = ExecuteRESTRequest(identity, new Uri(UrlBase, urlPath), HttpMethod.PUT);
                if (response != null && response.StatusCode == HttpStatusCode.NoContent)
                    return true;
                return false;
            }
        }
    }
