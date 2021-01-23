PodioAPI.Utils.ItemFields.ContactItemField contactField = item.Field<PodioAPI.Utils.ItemFields.ContactItemField>("Enter contact field id");
IEnumerable<PodioAPI.Models.Contact> myContact= contactField.Contacts;
    
foreach (var contact in myContact)
{
     string name = contact.Name;
     string user_id= contact.UserId;
}
