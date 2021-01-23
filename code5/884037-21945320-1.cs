            if (String.IsNullorEmpty(UUID)
                || UUID.Equals("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF")
                || UUID.Equals("00000000-0000-0000-0000-000000000000"))
            {
                throw new System.Exception("UUID is invalid.");
            }
            return UUID;
