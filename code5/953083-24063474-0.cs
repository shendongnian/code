          string query = 
          @"Select    
          [ID]
          ,[ProductTypeID]
          ,[SeriesID]
          ,[PartNumber]
          ,[Title]
          ,[SEOFriendlyURLTitle]
          ,[HTMLDescription]
          ,[HTMLValueAdded]
          ,[RoHSCompliant]
          ,[ULCompliant]
          ,[CECompliant]
          ,[Series]
          ,[BUSINESS_UNIT]
          ,[PACKAGING_TYPE]
          ,[PACK_QTY]
          ,[MOQ]
          ,[ORDER_MULTIPLE]
          ,[LEAD_TIME_WEEKS]
          ,[INTERNATIONAL_HARMONIZE_CODE]
          ,[ECCN_NUMBER]
          ,[COUNTRY_OF_ORIGIN]
          ,[IS_PART_STATIC_SENSITIVE]
          ,[IS_PART_LEAD_PB_FREE]
          ,[MOISTURE_SENSITIVITY_LEVEL_MSL]
          ,[REGISTERABLE]
          ,[TAPE_WIDTH]
          ,[TAPE_MATERIAL]
          ,[QtyOnHand]
          ,[QtyOnSalesOrder]
          ,[QtyOnBackOrder]
          ,[ProductLine]
          ,[Reach138Compliant]
          ,[ConflictMinerals]
          ,[WebEnabled]
          ,[DateAdded]
          ,[UpdateDate]
          ,[Reviewed]
          ,[ReviewedBy]
          ,[Deleted]
          ,[Book]
          ,[CustomSort]
          ,[ONEK]
          ,[FIVEK]
          ,[TENK]
          ,[TWENTYFIVEK]   
          ,[Fifty]
          ,[OneHundred]
          ,[FiveHundred]                                 
    FROM    Products.Products
    Join
    (SELECT Products.Prices.ProductID, 
        Max(IIf(Products.Prices.Code='ONEK',Products.Prices.Price,Null)) AS ONEK, 
        Max(IIf(Products.Prices.Code='FIVEK',Products.Prices.Price,Null)) AS FIVEK, 
        Max(IIf(Products.Prices.Code='TENK',Products.Prices.Price,Null)) AS TENK, 
        Max(IIf(Products.Prices.Code='TWENTYFIVEK',Products.Prices.Price,Null)) AS  TWENTYFIVEK,
        Max(IIf(Products.Prices.Code='Fifty',Products.Prices.Price,Null)) AS Fifty, 
        Max(IIf(Products.Prices.Code='OneHundred',Products.Prices.Price,Null)) AS OneHundred, 
        Max(IIf(Products.Prices.Code='FiveHundred',Products.Prices.Price,Null)) AS FiveHundred
    FROM Products.Prices
    GROUP BY Products.Prices.ProductID
    ) As pp
    ON Products.Products.ID = pp.ProductID";
