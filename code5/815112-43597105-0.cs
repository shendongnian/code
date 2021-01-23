            try
            {
                var entity = context.yourEntity.FirstOrDefault(o => o.Id == custId);
                if (entity == null) return false;
                entity.value= stNumber;
                entity.ModifiedBy = userId;
                entity.ModifiedDate = DateTime.Now;
                Db.SaveChanges();
                return true;
            }
            catch (DbUpdateException Ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return false;
            }
