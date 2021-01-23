    public class NotaFiscalEntrada : NotaFiscal<NotaFiscalEntradaItem>
    {
        public int NotaFiscalEntradaId { get; set; }
        public override ICollection<NotaFiscalEntradaItem> NotaFiscalItems { get; set; }
    }
