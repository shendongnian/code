        this.port = new ObservableSerialPort_string("COM4");
        this.messageObserver = Observable.Defer(() => port.TakeWhile(s => s != string.Empty)).Select(s => new Regex(@"...", RegexOptions.CultureInvariant).Replace(s, string.Empty)).Repeat();
        subject = new Subject<string>();
        var subSource = messageObserver.Subscribe(subject);
        subject.Subscribe(x => Console.WriteLine("raw: " + x));
        subject.Where(s => Regex.Match(s, @"...").Success)
               .Subscribe(x => Console.WriteLine("gauge: " + x));
