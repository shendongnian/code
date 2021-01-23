    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1 {
    
        internal class Program {
    
            static void Main(string[] args) {
    
                #region
                var store = @"
                    GB-ENG,   GB,       ENG,      England,             country,                  NULL
                    GB-SCT,   GB,       SCT,      Scotland,            country,                  NULL
                    GB-WLS,   GB,       WLS,      Wales,               country,                  NULL
                    GB-NIR,   GB,       NIR,      Northern Ireland,    province,                 NULL
                    GB-BKM,   GB,       BKM,      Buckinghamshire,     two-tier county,          ENG
                    GB-CAM,   GB,       CAM,      Cambridgeshire,      two-tier county,          ENG
                    GB-CMA,   GB,       CMA,      Cumbria,             two-tier county,          ENG
                    GB-SWK,   GB,       SWK,      Southwark,           London borough,           ENG
                    GB-STN,   GB,       STN,      Sutton,              London borough,           ENG
                    GB-TWH,   GB,       TWH,      Tower Hamlets,       London borough,           ENG
                    GB-LDS,   GB,       LDS,      Leeds,               metropolitan district,    ENG
                    GB-LIV,   GB,       LIV,      Liverpool,          metropolitan district,     ENG
                    GB-MAN,   GB,       MAN,      Manchester,          metropolitan district,    ENG
                ";
    
                var items = store
                    .Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Trim())
                    .Where(line => line != string.Empty)
                    .Select(line => line
                        .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(item => item.Trim())
                        .Where(item => item != string.Empty)
                        .ToArray()
                    )
                    .Select(item => new {
                        Code = item[0],
                        CountrySubdivisionCode = item[1],
                        SubdivisionCode = item[2],
                        Name = item[3],
                        Category = item[4],
                        ParentSubdivisionCode = item[5] == "NULL" ? default(string) : item[5]
                    })
                    .ToList();
                #endregion
    
                #region
                Console.WriteLine();
                items.Where(i1 =>
                    i1.ParentSubdivisionCode == null &&
                    items.Any(i2 => i2.ParentSubdivisionCode == i1.SubdivisionCode)
                )
                .OrderBy(i => i.CountrySubdivisionCode)
                .ThenBy(i => i.Category)
                .ThenBy(i => i.Name)
                .ToList()
                .ForEach(d => Console.WriteLine(d.Code));
                #endregion
    
                #region
                Console.WriteLine();
                var parentSubdivisionCodes = new HashSet<string>(items.Select(i => i.ParentSubdivisionCode));
                items.Where(i => 
                    i.ParentSubdivisionCode == null &&
                    parentSubdivisionCodes.Contains(i.SubdivisionCode)
                )
                .OrderBy(ps => ps.CountrySubdivisionCode)
                .ThenBy(ps => ps.Category)
                .ThenBy(ps => ps.Name)
                .ToList()
                .ForEach(d => Console.WriteLine(d.Code));
                #endregion
    
                #region
                Console.WriteLine();
                var csData = items;
                csData.Where(ps =>
                    ps.ParentSubdivisionCode == null &&
                    csData.Any(cs =>
                        cs.ParentSubdivisionCode == ps.SubdivisionCode
                    )
                )
                .OrderBy(ps => ps.CountrySubdivisionCode)
                .ThenBy(ps => ps.Category)
                .ThenBy(ps => ps.Name)
                .ToList()
                .ForEach(d => Console.WriteLine(d.Code));
                #endregion
    
                Console.ReadLine();
            }
        }
    }
