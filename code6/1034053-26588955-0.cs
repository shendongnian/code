    using System.Linq;
    using System.Threading.Tasks;
    
    ...
    
    var Tasks = this.ips.Select(ip => Task.Run(() => Check(ip))).ToArray();
    
    Task.WaitAll(Tasks);
    //inspect Task.Result to display status and perform further work
