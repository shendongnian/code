    INSERT INTO ZipCodeTerritory(Col1, Col2, Col3, ....)
    SELECT S.Col1, S.Col2, S.Col3, ....
    FROM   ZipCodeTerritoryTemp S LEFT JOIN ZipCodeTerritory T
    ON     S.ID = T.ID
    WHERE  T.ID IS NULL 
