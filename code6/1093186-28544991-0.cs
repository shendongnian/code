    public ContentResult DescargaPdfCompara(string id)
    {
        var rutaPdf = string.Empty;
        var type = "application/pdf";
        try
        {
            DateTime ahora = DateTime.Now;
            var numeroAleatorio = new Random();
            int numeroRandomico = numeroAleatorio.Next(100000000, 1000000000);
            string Ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reportes\" + Convert.ToString(ahora.Year + ahora.Month + ahora.Day + ahora.Hour + ahora.Minute + ahora.Second + numeroRandomico) + ".pdf");
            var result = SimuModel.ObtenerSabanaReporteComparativo(id);
            var resumen = SimuModel.ObtenerPreExcel(result);
            SimuModel.GenerarPdfCompa(result, resumen, Ruta);
            rutaPdf = Ruta;
            return Content(rutaPdf, type);
        }
        catch (Exception e)
        {
            throw e;
        }
        
    }
