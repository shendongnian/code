			Console.Clear();
			Console.WriteLine("\t Purchasing Fruit System\n");
			Console.WriteLine("Select Fruit");
			Console.WriteLine("A - Apples ");
			Console.WriteLine("B - Bananas ");
			Console.WriteLine("C - Cherries ");
			Console.Write("Enter Your Selection: ");
			string menuSelection = null;
			double totalPrice = double.MinValue;
			int numOfBoxes = int.MinValue;
			menuSelection = Console.ReadLine ();
			switch (menuSelection) {
			case "a":
			case "A":
				totalPrice = 0.25;
				menuSelection = "Apples";
				break;
			case "b":
			case "B":
				totalPrice = 1.60;
				menuSelection = "Bananas";
				break;
			case "c":
			case "C":
				totalPrice = 2.50;
				menuSelection = "Cherries";
				break;
			default:
				Console.WriteLine ("Invalid Selection !");
				return;
			}
			//Display Menu of Quantitites as Long as a Valid
			Console.WriteLine("How many boxes of {0} do you want ?", menuSelection);
			Console.WriteLine("1 - 5 {0}", menuSelection);
			Console.WriteLine("2 - 10 {0}", menuSelection);
			Console.WriteLine("3 - 15 {0}", menuSelection);
			Console.Write("Enter your Selection: ");
			//Get Quantity Selection
			string value = Console.ReadLine ();
			if (!int.TryParse (value, out numOfBoxes) || numOfBoxes < 1 || numOfBoxes > 3) {
				Console.WriteLine("Wrong value entered !");
				return;
				}
			switch (numOfBoxes) {
			case 1:
				totalPrice *= 5;
				break;
			case 2:
				totalPrice *= 10;
				break;
			case 3:
				totalPrice *= 15;
				break;
			}
			Console.WriteLine("Total price of {0} boxes of {1} is: {2}", numOfBoxes, menuSelection, totalPrice);
			Console.ReadLine();
