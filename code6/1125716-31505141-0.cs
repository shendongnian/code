     public class YourMessage { public string Text { get; set; } }
        internal class Program
        {
            private static void Main(string[] args)
            {
                var hostAddress = new Uri("rabbitmq://localhost/learningmt_orderservice");
                Bus.Initialize(sbc =>
                {
                    sbc.UseRabbitMq(rabbit =>
                    {
                        
                        rabbit.ConfigureHost(hostAddress,
                            chost =>
                            {
                                chost.SetUsername("guest");
                                chost.SetPassword("guest");
                            });
                        rabbit.Validate();
                    });
        
                    sbc.ReceiveFrom(hostAddress.AbsoluteUri);
                    sbc.Subscribe(subs =>
                    {
                        subs.Handler<YourMessage>(msg => Console.WriteLine(msg.Text));
                    });
                });
        
                Bus.Instance.Publish(new YourMessage {Text = "Hi"});
            }
        }
