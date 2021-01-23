    public IEnumerable<CTarifaAplicada> get_TarifasAplicadas(int id_proforma)
    {
    	var pt = (from ta in db.TarifaAplicada
    				where ta.IDProforma == id_proforma
    				join p in db.Proforma on ta.IDProforma equals p.ID
    				join pe in db.PortExpenses on ta.CodigoPE equals pe.CodigoPE
    				join v in db.Voucher on pe.IDVoucher equals v.No
    				select new CTarifaAplicada
    					{
    						CodigoFile = ta.CodigoFile,
    						CodigoPE = ta.CodigoPE,
    						Fecha = ta.Fecha,
    						Id = ta.Id,
    						IDProforma = ta.IDProforma,
    						ITBIS = ta.ITBIS,
    						Monto = ta.Monto,
    						DWT = p.DWT,
    						GRT=p.GRT,
    						LOA=p.LOA,
    						no_Voucher= v.No,
    						voucher=v.Description
    					});
    	return pt;
    }
