            /// <summary>
            /// English Name for country
            /// </summary>
            /// <param name="countryEnglishName"></param>
            /// <returns>
            /// Returns: RegionInfo object for successful find.
            /// Returns: Null if object is not found.
            /// </returns>
            static RegionInfo getRegionInfo (string countryEnglishName)
            {
                //Note: This is computed every time. This may be optimized
                var regionInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                   .Select(c => new RegionInfo(c.LCID))
                   .Distinct()
                   .ToList();
                 RegionInfo r = regionInfos.Find(
                        region => region.EnglishName.ToLower().Equals(countryEnglishName.ToLower()));                       
                 return r;
            }
