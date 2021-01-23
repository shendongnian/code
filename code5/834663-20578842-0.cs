     public T SaveReturnEntity(T entity)
        {
            try
            {
                this.Session.Save(entity);
            }
            catch
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
                throw;
            }
            this.Session.Flush();
            return entity;
        }
     return _sillyParent.SaveReturnEntity(sillyNameParent) != null;
     [Test]
        public void Save_sillyParent()
        {
            var sillyService = ServiceMiniMart.CreateSillyParent();
            
            var filter = new sillyQueryFilter();
            {
                CategoryId = 1
            };      
            var snp= new SillyNameParent
                {
                    Active = true,
                    Description= "Test"
                };
            if (sillyService.SaveSillyParent(snp))
            {
               snp.Category = new List<SillyChild>
                   {
                       new SillyChild
                           {
                               SillyNameParentId= snp.Id,
                               SillyNameCategoryId= filter.CategoryId.Value,
                               Parent = snp
                           }
                   };
            }
           
           var a =  sillyService.SaveSillyParent(snp);
        }
