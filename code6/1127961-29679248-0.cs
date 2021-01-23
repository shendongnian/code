    private static void EncryptFields(IDBContext context, int batchSize, int maxRetries)
    {
        while (true)
        {
            Debug.WriteLine(maxRetries.ToString());
            if (maxRetries == 0)
            {
                return;
            }
            var phones = context.Phones
                .Where(p => !(p.Number == null || p.Number.Trim() == ""))
                .Take(batchSize)
                .ToList();
            if (phones.Count() > 0)
            {
                foreach (var phone in phones)
                {
                    phone.Enc_Number = Encrypt(phone.Number);
                }
                context.SaveChanges();
                context.Dispose();
                context = new MyDBContext();
                context.Configuration.AutoDetectChangesEnabled = false;
                maxRetries--;
                continue;
            }
            else
            {
                break;
            }
        }
    }
