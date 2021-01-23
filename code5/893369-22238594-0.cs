    ServiceResponseCollection<ServiceResponse> responses = service.LoadPropertiesForItems(itemResults.Items, itItemPropSet);
    
    foreach (ServiceResponse response in responses)
    {
           if (response.Result == ServiceResult.Error)
           {
               // Handle the error associated
           }
           else
           {
               String subject = (response as GetItemResponse).Item.Subject;
           }
    }
