    MessageBus.Register<QuoteMessage>(m => {
        if (m.Symbol == "MSFT") {
            label1.Text =  m.Symbol+":"+m.Quote.ToString("n2");
            label2.Text =  m.Symbol+":"+m.Quote.ToString("n2");
        }
        else if (something) {
            // Do something else
            label3.Text =  m.Symbol+":"+m.Quote.ToString("n2");
        }
    });
