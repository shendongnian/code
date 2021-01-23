       NewPartHistory = new CdaService.PartHistory();
       NewPartHistory.EnteredBy = User.Current.UID;
       NewPartHistory.EntryDate = DateTime.UtcNow;
       NewPartHistory.PartId = ThisPart.Id;
       if()
       {  
          NewPartHistory.Entry = "Delivered Date of"......;
          return AddPartHistory(NewPartHistory );
       }
       else
       {
           NewPartHistory.Entry = "Delivery Date Changed from".....;
           return AddPartHistory(NewPartHistory );
       }
       //return comment object from AddPartHistory so that you can call this entire method and assert all properties
