    using System.Linq;
    using System.Web;
    using LicenciamentoMVC.Models;
     namespace LicenciamentoMVC.ModelsView
    {
    public class ProcessoCliente
    {
        public int IDProcesso { get; set; }
        public string NomeCliente { get; set; }
       
        public string  DataInserido { get; set; }
        public int Estado { get; set; }
    }
   
    public class ProcessoModel
    {
        private static ProcessoCliente entity;
        public static IQueryable<ProcessoCliente> GetListaProcessosClientes()
        {
            MvcApplication1Context db = new MvcApplication1Context();
            var processos =  (from p in db.Processos
                             join c in db.Clientes on p.IDCliente equals c.IDCliente
                              orderby p.IDProcesso descending
                              select new { IDProcesso = p.IDProcesso, NomeCliente = c.Nome, DataInserido = p.DataInserido, Estado = p.Estado }).ToList().Select(c => new ProcessoCliente
                              {
                                  IDProcesso = c.IDProcesso,
                                  NomeCliente = c.NomeCliente,
                                  DataInserido = c.DataInserido.ToString(),
                                  Estado=c.Estado
                              });
            return processos.AsQueryable<ProcessoCliente>();
        }
    }
    }
