    using System;
    using System.Collections.Generic;
    using Autofac;
    
    namespace AutoFac
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			// CREATE THE IOC ENGINE AND CONTAINER
    			var builder = new ContainerBuilder();
    			IContainer container;
    
    			// CREATE THE DEPENDENCY CHAIN REGISTRATION
    			builder.RegisterType<Receipt>()
    				.Named<IReceipt>("StandardReceipt")
    				.WithParameter(new TypedParameter(typeof(IProcessor), new PrinterProcessor()))
    				.WithParameter(new TypedParameter(typeof(IFormatter), new StandardReceiptFormatter()));
    
    			builder.RegisterType<Receipt>()
    				.Named<IReceipt>("GiftReceipt")
    				.WithParameter(new TypedParameter(typeof(IProcessor), new PrinterProcessor()))
    				.WithParameter(new TypedParameter(typeof(IFormatter), new GiftReceiptFormatter()));
    
    			builder.RegisterType<Receipt>()
    				.Named<IReceipt>("EmailReceipt")
    				.WithParameter(new TypedParameter(typeof(IProcessor), new EmailProcessor()))
    				.WithParameter(new TypedParameter(typeof(IFormatter), new EmailReceiptFormatter()));
    
    
    			// COMPILE THE AUTOFAC REGISTRATION
    			container = builder.Build();
    
    			// SETUP INITIALIZATION STUFF - THINGS THAT WOULD ORDINARILY HAPPEN AS PART OF EXTERNAL SYSTEMS INTEGRATION
    			int someBogusDatabaseIdentifier = 1;
    
    			var standardReceipt = container.ResolveNamed<IReceipt>("StandardReceipt");
    			standardReceipt.PrintReceipt(someBogusDatabaseIdentifier);
    
    			var giftReceipt = container.ResolveNamed<IReceipt>("GiftReceipt");
    			giftReceipt.PrintReceipt(someBogusDatabaseIdentifier);
    
    			var emailReceipt = container.ResolveNamed<IReceipt>("EmailReceipt");
    			emailReceipt.PrintReceipt(someBogusDatabaseIdentifier);
    
    			Console.ReadLine();
    		}
    	}
    }
