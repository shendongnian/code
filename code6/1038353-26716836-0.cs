    Dictionary<string,int> namesForCarousels = new Dictionary<string,int>();
...
    if (cells.Length > 1)
    {
    	var name = cells[1];
    	int carouselNumber;
    	if (namesForCarousels.TryGetValue(name, out carouselNumber) == false)
    		{
    			carouselNumber = iCarousel++;
    			namesForCarousels[name] = carouselNumber;
    		}
    	if (i == 0)
    	sb.Append("Location".PadRight(15));
    	else
    	sb.Append(String.Format("{0}:{1}", CarouselName, carouselNumber).PadRight(15));
    }
