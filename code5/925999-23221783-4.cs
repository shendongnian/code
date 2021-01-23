    class Program {
    		static void Main(string[] args) {
    			using (var channelFactory =
    				new ChannelFactory<ICalculatorService>("calculatorservice")) {
    
    				ICalculatorService proxy = channelFactory.CreateChannel();
    				Console.WriteLine(proxy.Add(1, 2));
    				Console.Read();
    			}
    			Console.Read();
    		}
    	}
