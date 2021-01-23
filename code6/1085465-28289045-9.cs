    var xs = Observable.Using(
        () =>
        {                        
            var processHandle = /* code to create process */
            return Disposable.Create(() => /* code to kill process using processHandle */;
        },
        // Rest of code...
    
