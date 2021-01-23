    ViewBag.RoleId = new SelectList(unitOfWork.roleRepository.Get(), 
                     "Id", 
                     "RoleName",
                     unitOfWork.roleRepository.Get()
                               .Where(x=>x.Id == user.RoleId)
                               .FirstOrDefault());
