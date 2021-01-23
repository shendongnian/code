        private void FillItemVerifierCache()
        {
            // Attempt to cast the verifier 
            var potentiallyCacheableVerifier =
                _DoodadValidator.ItemVerifier as ICacheFillable<string>;
            // if the item is cacheable 
            if (potentiallyCacheableVerifier != null)
            {
                // get all of the items into a list of strings
                var cacheItems = from x in _doodad.Items select x.StringProperty;
                // fill the cache with the items
                potentiallyCacheableVerifier.FillCache(cacheItems);
            }
        }
