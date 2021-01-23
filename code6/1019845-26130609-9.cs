    using System;
    using System.Collections.Generic;
    using Autofac;
    
    namespace MyAutoFacTest
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			// CREATE THE IOC ENGINE AND CONTAINER
    			var builder = new Autofac.ContainerBuilder();
    			Autofac.IContainer container;
    
    			// CREATE THE DEPENDENCY CHAIN REGISTRATION
    			builder.RegisterType<Printer>()
    				.Named<IPrinter>("My Default Printer");
    
    			builder.RegisterType<PrinterProcessor>()
    				.Named<IProcessor>("PrinterProcessor")
    				.WithParameter(Autofac.Core.ResolvedParameter.ForNamed<IPrinter>("My Default Printer"));
    
    			builder.RegisterType<EmailProcessor>()
    				.Named<IProcessor>("EmailProcessor");
    
    			builder.RegisterType<StandardReceiptFormatter>()
    				.Named<IFormatter>("StandardReceiptFormatter");
    
    			builder.RegisterType<GiftReceiptFormatter>()
    				.Named<IFormatter>("GiftReceiptFormatter");
    
    			builder.RegisterType<EmailReceiptFormatter>()
    				.Named<IFormatter>("EmailReceiptFormatter");
    
    			builder.RegisterType<Receipt>()
    				.Named<IReceipt>("StandardReceipt")
    				.WithParameter(Autofac.Core.ResolvedParameter.ForNamed<IProcessor>("PrinterProcessor"))
    				.WithParameter(Autofac.Core.ResolvedParameter.ForNamed<IFormatter>("StandardReceiptFormatter"));
    
    			builder.RegisterType<Receipt>()
    				.Named<IReceipt>("GiftReceipt")
    				.WithParameter(Autofac.Core.ResolvedParameter.ForNamed<IProcessor>("PrinterProcessor"))
    				.WithParameter(Autofac.Core.ResolvedParameter.ForNamed<IFormatter>("GiftReceiptFormatter"));
    
    			builder.RegisterType<Receipt>()
    				.Named<IReceipt>("EmailReceipt")
    				.WithParameter(Autofac.Core.ResolvedParameter.ForNamed<IProcessor>("EmailProcessor"))
    				.WithParameter(Autofac.Core.ResolvedParameter.ForNamed<IFormatter>("EmailReceiptFormatter"));
    
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
