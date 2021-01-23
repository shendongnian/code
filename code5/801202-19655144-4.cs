    public class IdentityUserManager
    {
        public void Add(IdentityUser idUser)
        {
            using(var idUserRepository = new EFRepository<IdentityUser>(Database.GetContext())
            {
                idUserRepository.Add(idUser);
            }
        }
    }
