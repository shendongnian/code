        public bool CheckIfUserExists(string email)
        {
            if (email.Length > 254)
            {                
                throw new WebFaultException<string>("{EmailTooLong" + ":" + "Error 94043" + "}", System.Net.HttpStatusCode.BadRequest);
            }
            return DBUtility.CheckIfUserExists(email);
        }
