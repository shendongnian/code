        if (usuario != null)
              {
                usuario.Id = user.Id;
                usuario.UserName = user.UserName;
                usuario.Email = user.Email;
                this.Context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                this.Context.SaveChanges();// Or you may try await this.Context.SaveChangesAsync();
           }
