    public class CatalogoDeCuentas       
    {
       public int CodigoAgrupadorCuentasID { get; set; }
       public string text { get; set; }
   
       [ForeignKey("CodigoAgrupadorCuentasID")]
       public virtual CuentasDelMes CuentasDelMes { get; set; }
    }
