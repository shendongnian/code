    ...
    using HPCloud.Common;
    using HPCloud.Objects;
    using HPCloud.Objects.Utility;
    using HPCloud.Objects.DataAccess;
    using HPCloud.Objects.Domain;
    using HPCloud.Objects.Domain.Compute;
    using HPCloud.Objects.Domain.Admin;
    session = Session.CreateSession("accessKey", "secretKey", "tennantID");
    private Session session = null;
        public static string GenerateUrl(Session session, string bucket_name, string key)
        {
            string baseUrl = session.Context.ServiceCatalog.GetService(HPCloud.Objects.Domain.Admin.Services.ObjectStorage).Url;
            return baseUrl + "/" + bucket_name + "/" + key;
        }
    
