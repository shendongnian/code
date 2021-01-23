    public class CardPrinter
    {
        public void PrintStaffCard(string p_persoons)
        {
            Debug.WriteLine(p_persoons);
    
            foreach (string persoon in p_persoons.Split(','))
            {
                int p_persoon = Convert.ToInt32(persoon.Trim());
                var cardInfo = await this.GetStaffDataAsync(p_persoon);
    			await this.SendStaffCardToPrinterAsync(cardInfo);
            }
        }
    
    	private Task<CardInfo.CardInfo> GetStaffDataAsync(int p_persoon)
    	{
    		var tcs = new TaskCompletionSource<CardInfo.CardInfo>();
    		
    		PictureServiceClient proxy = new PictureServiceClient();
    
            proxy.GetPersonelCardInfoCompleted += (s, e) =>
    		{
    			if (e.Error != null)
    			{
    				Debug.WriteLine(e.Error.Message);
    				tcs.SetException(e.Error);
    			}
    			else
    			{
    				tcs.SetResult(e.Result);
    			}
    		};
    		
            proxy.GetPersonelCardInfoAsync(p_persoon);
    		
    		return tcs.Task;
    	}
    	
        private Task SendStaffCardToPrinterAsync(CardInfo.CardInfo card)
        {
            Canvas canvas = new Canvas();
    
            //Do some stuff
    
    	    var tcs = new TaskCompletionSource<object>();
    		
            PrintDocument pd = new PrintDocument();
    		
            pd.PrintPage += (s, e) => 
    		{
                e.PageVisual = canvas;
    			tcs.SetResult(null);
    		};
    
            pd.Print(card.accountNr, null, true);
    		
    		return tcs.Task;
        }
    }
