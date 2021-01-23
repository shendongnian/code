	ALTER PROC [dbo].[spGetAllProviders]
	AS
	SELECT Provider.*,
           ProviderDetails.ProviderId,
           ProviderDetails.ProviderDetailsID,
           ProviderDetails.Certification,
           ProviderDetails.Specialization,
	       ProviderDetails.TaxonomyCode,
           ProviderDetails.ContactNumber,
           ProviderDetails.ContactEmail 
    FROM Provider 
	INNER JOIN ProviderDetails 
	ON Provider.ProviderId = ProviderDetails .ProviderId
	WHERE Provider.ProviderStatus = 1
