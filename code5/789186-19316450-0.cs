    Console.WriteLine("Test started");
    var testLocation = new CLLocation(52.268157,-1.4209);
    Task.Factory.StartNew(async () => 
        {
            try{
                for (var i=0; i < 100; i++)
                {
                    Console.WriteLine("Starting iteration {0}", i);
                    var res = await _coder.ReverseGeocodeLocationAsync(testLocation);
                    Console.WriteLine(res[0].AdministrativeArea);
                    Console.WriteLine("Finished iteration {0}", i);
                }
            }catch(Exception e){
                Console.WriteLine (e);
            }
        });
    Console.WriteLine("Finished");
