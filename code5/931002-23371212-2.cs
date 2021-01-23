    //Create a separate thread so that the GUI thread doesn't sleep through updates:
    using System.Threading;
    new Thread(() => {
        foreach (var node in stack)
        {
            //The invoke only needs to be used when updating GUI Elements
            this.Invoke((MethodInvoker)delegate() {
                //Everything inside of this Invoke runs on the GUI Thread
                int[,] unstrung = node.unstringNode(node); // turns node of int[] into board of  int[,]
                blocks.setBoard(unstrung); // sets the board to pass in to the GUI
                DrawBoard(); // Takes the board (int[,]) and sets the squares on the GUI to match it.
            });
            Thread.Sleep(500);
        }
    }).Start();
