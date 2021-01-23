    try
        {
            EnvelopeInformation envelopeInfo = new EnvelopeInformation();
			envelopeInfo.AccountId = _accountId;
			envelopeInfo.Subject = "My Subject";
			envelopeInfo.EmailBlurb = "My email blurb.";
			tracing.Trace("Enter using...");
			using (var scope = new System.ServiceModel.OperationContextScope(_apiClient.InnerChannel))
			{
				tracing.Trace("httpRequestProperty");
			
				// ... remaining code ...
			}
        }
        // Catch the InvalidDataContractException here. 
        catch(InvalidDataContractException iExc)
        {
            Console.WriteLine("You have an invalid data contract: ");
            Console.WriteLine(iExc.Message);
            Console.ReadLine();
        }
          catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
            Console.WriteLine(exc.ToString() );
            Console.ReadLine();
        }
