    using System.Threading;
    new Thread(new ThreadStart(delegate() {
        foreach (var node in stack)
        {
            //The invoke only needs to be used when updating GUI Elements - but I just put it around everything besides the sleep since it shouldn't hurt.
            this.Invoke((MethodInvoker)delegate() {
                int[,] unstrung = node.unstringNode(node); // turns node of int[] into board of  int[,]
                blocks.setBoard(unstrung); // sets the board to pass in to the GUI
                DrawBoard(); // Takes the board (int[,]) and sets the squares on the GUI to match it.
            });
            Thread.Sleep(500);
        }
    }).Start();
