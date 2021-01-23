	IObservable<System.Drawing.Image> fuzz = ...
	IObservable<System.Drawing.Image> channel1 = ...
	IObservable<System.Drawing.Image> channel2 = ...
	
	IObservable<string> eButton1 = ... // produces string "eButton1" when clicked
	IObservable<string> eButton2 = ... // produces string "eButton2" when clicked
	
	var output =
	(
		from button in eButton1.Merge(eButton2).StartWith("")
		select
			button == "eButton1"
				? channel1
				: (button == "eButton2"
					? channel2 
					: fuzz)
	).Switch();
