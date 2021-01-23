    private System.Threading.Timer _timer = new Timer
    (
        onSave, 
        null,  // State; not used.
        TimeSpan.FromMinutes(5),
        TimeSpan.FromMinutes(5)
    );
