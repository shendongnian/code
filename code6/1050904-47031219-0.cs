        var adresse = dr["SecondaryEmail"].ToString();
        int iMessageInArray = mailMessage.To.Count();
        if(iMessageInArray > 0)
        {
            foreach (var mailadress in mailMessage.To)
            {
                if (mailadress.Address == adresse)
                {
                    mailMessage.To.Remove(mailadress);
                }
            }
        }
