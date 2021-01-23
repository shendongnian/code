    public class MedicineStrength
    {
        [Key]
        public int Id { get; set; }
        public int? MedicineId { get; set; }
        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }
        public double Strength { get; set; }
        public int? MetricPrefixId { get; set; }
        [ForeignKey("MetricPrefixId")]
        public virtual MetricPrefix MetricPrefix { get; set; }
        public int? UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
        public int? MedicineTypeId { get; set; }
        [ForeignKey("MedicineTypeId")]
        public virtual MedicineType MedicineType { get; set; }
    }
