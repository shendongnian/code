    using (var context = new BetaalplatformContext())
            {
                var dienstverleners = context.Dienstverleners.Include(dv => dv.Omgeving)
                                                             .Include(dv => dv.Platformen)
                                                             .Include(dv => dv.Platformen.Select(pl => pl.Deelnemers))
                                                             .Include(dv => dv.Platformen.Select(pl => pl.Deelnemers.Select(dn => dn.Betaalregelingen)))
                                                             .Include(dv => dv.Platformen.Select(pl => pl.Deelnemers.Select(dn => dn.Betaalregelingen.Select(br => br.Aanvrager))))
                                                             .Include(dv => dv.Platformen.Select(pl => pl.Deelnemers.Select(dn => dn.Betaalregelingen.Select(br => br.Betaler))))
                                                             .ToList();
                dienstverleners.ForEach(
                    dv => dv.Platformen.ForEach(
                        pl => pl.Deelnemers.ForEach(
                            dn => dn.Betaalregelingen = dn.Betaalregelingen
                                .Where(br2 => br2.BevestigdOp.HasValue && br2.ExportDatum.HasValue && !br2.StatistiekDatum.HasValue)
                                .ToList()
                            )
                        )
                    );
                return dienstverleners;
            }
