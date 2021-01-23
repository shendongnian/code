    public ActionResult Convert(double? np1, string p2)
    {
        if (np1 == null)
        {
            return RedirectToRoute(new
            {
                controller = "Index",
                action = "Index"
            });
        }
        var p1 = np1.GetValueOrDefault();
        Exercise07IndexViewModel model = new Exercise07IndexViewModel { Conv = p1 };
                    
        if( p2 == "C2F" )
        {
            var math = ((9 * p1) / 5 ) + 32;
            Exercise07ConvertViewModel c2f = new Exercise07ConvertViewModel { OriginalValue = p1, OriginalUnit = "°C", ConvertedValue = math, ConvertedUnit = "°F", Convert = p2 };
            return View("Convert", c2f);
        }
        else if (p2 == "F2C")
        {
            var math = ((p1 - 32) * 5) / 9;
            Exercise07ConvertViewModel f2c = new Exercise07ConvertViewModel { OriginalValue = p1, OriginalUnit = "°F", ConvertedValue = math, ConvertedUnit = "°C", Convert = p2 };
            return View(f2c);
        }
        else if (p2 == "oz2g")
        {
            var math = 28.35 * p1;
            Exercise07ConvertViewModel oz2g = new Exercise07ConvertViewModel { OriginalValue = p1, OriginalUnit = "oz", ConvertedValue = math, ConvertedUnit = "g", Convert = p2 };
            return View("Convert", oz2g);
        }
        else if (p2 == "g2oz")
        {
            var math = 0.035 * p1;
            Exercise07ConvertViewModel g2oz = new Exercise07ConvertViewModel { OriginalValue = p1, OriginalUnit = "g", ConvertedValue = math, ConvertedUnit = "oz", Convert = p2 };
            return View("Convert", g2oz);
        }
        else if (String.IsNullOrEmpty(p2) || p2 == "ScaleNotSupported")
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View("Convert", model);
        }
    }
