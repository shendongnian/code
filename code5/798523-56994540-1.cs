    // data 
            var p_estadoAcreditacion = "NO";
            var estadoAcreditacion = new List<SelectListItem>();
            estadoAcreditacion.Add(new SelectListItem { Text = "(SELECCIONE)"    , Value = " "    });
            estadoAcreditacion.Add(new SelectListItem { Text = "SI"              , Value = "SI"   });
            estadoAcreditacion.Add(new SelectListItem { Text = "NO"              , Value = "NO"   });
    
            if (!string.IsNullOrEmpty(p_estadoAcreditacion))
            {
                estadoAcreditacion.First(x => x.Value == p_estadoAcreditacion.Trim()).Selected = true;
            }
             ViewData["DATA_ACREDITO_MODELO_INTEGRADO"] = estadoAcreditacion;
