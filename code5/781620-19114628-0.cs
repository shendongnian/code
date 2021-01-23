    var temp = (from bl in context.buttonLocations
            join b in context.Buttons
            on bl.ButtonID equals b.ButtonID into buttons
            from button in buttons.DefaultIfEmpty()
            let description = (
                    from d in context.Descriptions
                    where
                        d.LanguageID == languageID
                     && (
                          (
                            d.ValueID == bl.ButtonLocationID
                            && d.DescriptionOriginID == descriptionOriginID
                          )
                        ||
                          (
                            d.ValueID == b.ButtonID 
                            d.DescriptionOriginID == (short)DescriptionOriginEnum.Button
                          )
                        )
                    // this line puts custom descriptions first
                    orderby d.DescriptionOriginID == (short)DescriptionOriginEnum.Button
                            ? 1
                            : 0
                    select d
                    )
                    // this will get a custom description if there was one, otherwise
                    // the first one will be the default description
                    .FirstOrDefault() 
            where bl.ButtonGroupID == buttonGroupId
            select new
            {
              Button = button,
              ButtonLocation = bl,
              Description = description
            })
            .ToList();
