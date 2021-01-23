    WITH NewAndChanged AS (
        SELECT Stage.Id
              ,Stage.Col1
              ,Stage.Col2
        FROM Stage
      EXCEPT
        SELECT Master.Id
              ,Master.Col1
              ,Master.Col2
        FROM Master
    )
    MERGE Master
    USING NewAndChanged
          ON Master.Id = NewAndChanged.Id
    WHEN MATCHED
         THEN UPDATE SET
             Col1 = NewAndChanged.Col1
            ,Col2 = NewAndChanged.Col2
    WHEN NOT MATCHED
         THEN INSERT (
                  Id
                 ,Col1
                 ,Col2
              )
              VALUES (
                  NewAndChanged.Id
                 ,NewAndChanged.Col1
                 ,NewAndChanged.Col2
              )
