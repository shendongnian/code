        public override IEnumerable<Product> Get()
        {
            var result = _cacheManager.Get(PreLoadCacheKey) as IEnumerable<Product>;
            if (result != null)
                return result;
            return DetachAndReturn();
        }
        private IEnumerable<Product> DetachAndReturn()
        {
            foreach (var product in base.Get())
            {
                base.Detach(product);
                yield return product;
            }  
        }
