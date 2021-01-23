        private static string CalculateToken(User user)
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = BitConverter.GetBytes(user.ID);
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            return token;
        }
