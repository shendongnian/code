    foreach (Contact contact in results.Contacts)
    {
        List<ContactInformationType> lookup = new List<ContactInformationType>();
        lookup.Add(ContactInformationType.DisplayName);
        lookup.Add(ContactInformationType.Photo);
        IDictionary<ContactInformationType, object> contactDetails = contact.GetContactInformation(lookup);
        Stream s = (Stream)contactDetails[ContactInformationType.Photo];
        if (s != null)
        {
            string PicturePath = "Photos\\" + (string)contactDetails[ContactInformationType.DisplayName] + ".jpg";
            StreamWriter sw = new StreamWriter(PicturePath, false);
            CopyStream(s, sw.BaseStream);
            sw.Close();
        }
    }
