    var result = liquidtyTimezoneData.GroupBy(x => new { x.LP, x.Timezone, x.Ask })
                                     .Select(x => new
                                                 {
                                                     LP = x.Key.LP,
                                                     Timezone = x.Key.Timezone,
                                                     Ask = x.Key.Ask,
                                                     Sum = x.Sum(z => z.Size)
                                                  });
