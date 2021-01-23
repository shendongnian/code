    protected async Task  DoStuffAsync()
    {
        SomeThing thing = new SomeThing { ID = 5 };
        SomeRepository rep = new SomeRepository();
    
        // We need to run all three Get... methods in parallel
        // As soon as a Get... method completes we need to save the result to the correct property on thing and call the Save... method .
    
        Func<Task<X>> getRedFunc = async() =>
        {
            var result = await rep.GetRedAsync();
        	thing.Color1 = result;
        	await rep.SaveRedAsync(thing);
        	return result;
        };
    
        var getRed = getRedFunc();
        
        var getBlue = rep.GetBlueAsync();
        var getGreen = rep.GetGreenAsync();
        
        await Task.WhenAll(getRed, getBlue, getGreen);
    }
