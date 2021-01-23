     return (from p in context.Products
                    join t in context.Translations
                    on new
                    {
                        Id = p.ProductID,
                        langId = languageID,
                        tOriginId = translationOriginID
                    }
                    equals new
                    {
                        Id = d.ValueID,
                        langId = d.LanguageID,
                        tOriginId = d.TranslationOriginID
                    }
                    into other
                    from x in other.DefaultIfEmpty()
                    select new
                    {
                        Product = p,
                        Translation = x
                    })
                    .ToList().ConvertAll(x => new Product()
                    {
                        Code = x.Product.Code,
                        Translation = x.Translation,
                        /** Other properties **/
                    });
