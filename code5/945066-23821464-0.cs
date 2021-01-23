    using(EntityClass entities = new EntityClass())
    {
    var email = 
          (from biz in entities.BusinessContacts
          where biz.businessid = bid
          from codes in entities.ContactsContactCodes
          where codes.contactcodesid = cid
          from c in entites.Contacts
          where c.contactsid == codes.contactsid && c.contactsid == biz.contactsid
          select c.email).FirstOrDefault();     
    }
