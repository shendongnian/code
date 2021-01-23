    // <summary>
                /// Multiplys numbers and returns the product as rounded to the nearest 2 decimal places.
                /// </summary>
                /// <param name="decimals"></param>
                /// <returns></returns>
                public static decimal MultiplyDecimals(params decimal[] decimals)
                {
        
                    decimal product = 1;
        
                    foreach (var @decimal in decimals)
                    {
                        product *= @decimal;
                    }
                    decimal roundProduct = Math.Round(product, 2);
                    return roundProduct;
                }
