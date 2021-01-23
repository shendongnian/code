    List<User> users = UnitOfWork.UserRepository.Get(
               user =>
               ( String.IsNullOrEmpty( FirstName ) || user.FirstName.Contains( FirstName ) ) &&
               ( String.IsNullOrEmpty( LastName ) || user.LastName.Contains( LastName ) ) 
               ).ToList();
