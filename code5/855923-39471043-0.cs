        'Sample code for the non-continuous inventory system
        Dim svrLandedCost As SAPbobsCOM.LandedCostsService = oCompany.GetCompanyService().GetBusinessService(SAPbobsCOM.ServiceTypes.LandedCostsService)
 
        Dim oLandedCost As SAPbobsCOM.LandedCost = svrLandedCost.GetDataInterface(SAPbobsCOM.LandedCostsServiceDataInterfaces.lcsLandedCost)
 
        Dim oLandedCostEntry As Long = 0
 
        Dim GRPOEntry As Integer = 15
 
        'Landed cost document - item tab line 1
        Dim oLandedCost_ItemLine As SAPbobsCOM.LandedCost_ItemLine
        oLandedCost_ItemLine = oLandedCost.LandedCost_ItemLines.Add
        oLandedCost_ItemLine.BaseDocumentType = SAPbobsCOM.LandedCostBaseDocumentTypeEnum.asGoodsReceiptPO
        oLandedCost_ItemLine.BaseEntry = GRPOEntry
        oLandedCost_ItemLine.BaseLine = 0
 
        'Landed cost document - item tab line 2
        oLandedCost_ItemLine = oLandedCost.LandedCost_ItemLines.Add()
        oLandedCost_ItemLine.BaseDocumentType = SAPbobsCOM.LandedCostBaseDocumentTypeEnum.asGoodsReceiptPO
        oLandedCost_ItemLine.BaseEntry = GRPOEntry
        oLandedCost_ItemLine.BaseLine = 1
 
        'Landed cost document - item tab line 3
        'This is a split line –split from second line (BaseEntry = 13, BaseLine = 1)
        oLandedCost_ItemLine = oLandedCost.LandedCost_ItemLines.Add()
        oLandedCost_ItemLine.BaseDocumentType = SAPbobsCOM.LandedCostBaseDocumentTypeEnum.asGoodsReceiptPO
        oLandedCost_ItemLine.BaseEntry = GRPOEntry
        oLandedCost_ItemLine.BaseLine = 1
        oLandedCost_ItemLine.Quantity = 2
        oLandedCost_ItemLine.Warehouse = "02"
 
        'Landed cost document - cost tab line 1
        Dim oLandedCost_CostLine As SAPbobsCOM.LandedCost_CostLine
        oLandedCost_CostLine = oLandedCost.LandedCost_CostLines.Add
        oLandedCost_CostLine.LandedCostCode = "CB"
        'Suppose the vendor currency is Foreign Currency, if in local currency should set 'oLandedCost_CostLine.amount
        oLandedCost_CostLine.amount = 100
        'oLandedCost_CostLine.AllocationBy = SAPbobsCOM.LandedCostAllocationByEnum.asCashValueAfterCustoms
 
        'Landed cost document - cost tab line 2
        oLandedCost_CostLine = oLandedCost.LandedCost_CostLines.Add
        oLandedCost_CostLine.LandedCostCode = "EQ"
        oLandedCost_CostLine.amount = 100
        'oLandedCost_CostLine.AllocationBy = SAPbobsCOM.LandedCostAllocationByEnum.asCashValueAfterCustoms
 
        'Landed cost document - cost tab line 3
        oLandedCost_CostLine = oLandedCost.LandedCost_CostLines.Add
        oLandedCost_CostLine.LandedCostCode = "EQ"
        oLandedCost_CostLine.amount = 100
        'oLandedCost_CostLine.AllocationBy = SAPbobsCOM.LandedCostAllocationByEnum.asCashValueAfterCustoms
        oLandedCost_CostLine.CostType = SAPbobsCOM.LCCostTypeEnum.asVariableCosts
 
 
        Dim oLandedCostParams As SAPbobsCOM.LandedCostParams = svrLandedCost.GetDataInterface(SAPbobsCOM.LandedCostsServiceDataInterfaces.lcsLandedCostParams)
 
        'Add a landed cost
        Try
            oLandedCostParams = svrLandedCost.AddLandedCost(oLandedCost)
            oLandedCostEntry = oLandedCostParams.LandedCostNumber
        Catch ex As Exception
            'exception process
            MsgBox(ex.Message)
        End Try
 
        'Update a landed cost
        Dim oLandedCostUpdateParams As SAPbobsCOM.LandedCostParams = svrLandedCost.GetDataInterface(LandedCostsServiceDataInterfaces.lcsLandedCostParams)
        Dim oLandedCostUpdate As SAPbobsCOM.LandedCost = svrLandedCost.GetDataInterface(LandedCostsServiceDataInterfaces.lcsLandedCost)
 
        'Operate on the landed cost
        oLandedCostUpdateParams.LandedCostNumber = oLandedCostEntry
        'Get the landed cost
        Try
            oLandedCostUpdate = svrLandedCost.GetLandedCost(oLandedCostUpdateParams)
        Catch ex As Exception
            'exception process
            MsgBox(ex.Message)
        End Try
 
 
        'Split functionality, split line 1
        Dim oLandedCostUpdate_ItemLine As SAPbobsCOM.LandedCost_ItemLine
        oLandedCostUpdate_ItemLine = oLandedCostUpdate.LandedCost_ItemLines.Add()
        oLandedCostUpdate_ItemLine.OriginLine = 1
        oLandedCostUpdate_ItemLine.Quantity = 1
        oLandedCostUpdate_ItemLine.Warehouse = "02"
 
 
        Dim oLandedCostUpdate_CostLine As SAPbobsCOM.LandedCost_CostLine
        oLandedCostUpdate_CostLine = oLandedCostUpdate.LandedCost_CostLines.Add()
 
        oLandedCostUpdate_CostLine.LandedCostCode = "QA"
        oLandedCostUpdate_CostLine.amount = 50
        oLandedCostUpdate_CostLine.CostType = SAPbobsCOM.LCCostTypeEnum.asVariableCosts
        oLandedCostUpdate_CostLine.AllocationBy = LandedCostAllocationByEnum.asQuantity
 
 
        Try
            svrLandedCost.UpdateLandedCost(oLandedCostUpdate)
        Catch ex As Exception
            'exception process
            MsgBox(ex.Message)
        End Try
 
    End Sub
