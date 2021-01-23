    private void WaitNSeconds(int segundos)
    {
        if (segundos < 1) return;
        DateTime _desired = DateTime.Now.AddSeconds(segundos);
        while (DateTime.Now < _desired) {
             System.Windows.Forms.Application.DoEvents();
        }
    }
