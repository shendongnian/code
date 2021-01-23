    // ---------------------------------------------------------------------------------------------------------------------
    // <copyright file="Controller.cs" company="Care Controls">
    //   Copyright (c) Care Controls Inc. All rights reserved.
    // </copyright>
    // ---------------------------------------------------------------------------------------------------------------------
    namespace CareControls.Modbus.Tcp
    {
        using System;
        using CareControls.Modbus.Tcp.Internal;
        public class Controller
            : ConnectionInfo,
              HoldingRegisterReader,
              InputRegisterReader,
              CoilReader,
              InputReader,
              CoilWriter,
              HoldingRegisterWriter
        {
            public Controller()
            {
                this.newDeviceConnection = () => new NModbusDeviceConnection(this.IP);
            }
            public virtual string IP { get; set; }
            public virtual ushort[] ReadHoldingRegisters(ushort startAddress, ushort numberOfRegisters)
            {
                using (var connection = this.newDeviceConnection())
                {
                    return connection.ReadHoldingRegisters(startAddress, numberOfRegisters);
                }
            }
            public virtual ushort[] ReadInputRegisters(ushort startAddress, ushort numberOfRegisters)
            {
                using (var connection = this.newDeviceConnection())
                {
                    return connection.ReadInputRegisters(startAddress, numberOfRegisters);
                }
            }
            public virtual bool[] ReadCoils(ushort startAddress, ushort numberOfCoils)
            {
                using (var connection = this.newDeviceConnection())
                {
                    return connection.ReadCoils(startAddress, numberOfCoils);
                }
            }
            public virtual bool[] ReadInputs(ushort startAddress, ushort numberOfInputs)
            {
                using (var connection = this.newDeviceConnection())
                {
                    return connection.ReadInputs(startAddress, numberOfInputs);
                }
            }
            public virtual void WriteSingleCoil(ushort address, bool value)
            {
                using (var connection = this.newDeviceConnection())
                {
                    connection.WriteSingleCoil(address, value);
                }
            }
            public virtual void WriteMultipleCoils(ushort startAddress, bool[] values)
            {
                using (var connection = this.newDeviceConnection())
                {
                    connection.WriteMultipleCoils(startAddress, values);
                }
            }
            public virtual void WriteSingleHoldingRegister(ushort address, ushort value)
            {
                using (var connection = this.newDeviceConnection())
                {
                    connection.WriteSingleHoldingRegister(address, value);
                }
            }
            public virtual void WriteMultipleHoldingRegisters(ushort startAddress, ushort[] values)
            {
                using (var connection = this.newDeviceConnection())
                {
                    connection.WriteMultipleHoldingRegisters(startAddress, values);
                }
            }
            string ConnectionInfo.IP
            {
                get
                {
                    return this.IP;
                }
                set
                {
                    this.IP = value;
                }
            }
            ushort[] HoldingRegisterReader.Read(ushort startAddress, ushort numberOfRegisters)
            {
                return this.ReadHoldingRegisters(startAddress, numberOfRegisters);
            }
            ushort[] InputRegisterReader.Read(ushort startAddress, ushort numberOfRegisters)
            {
                return this.ReadInputRegisters(startAddress, numberOfRegisters);
            }
            bool[] CoilReader.Read(ushort startAddress, ushort numberOfCoils)
            {
                return this.ReadCoils(startAddress, numberOfCoils);
            }
            bool[] InputReader.Read(ushort startAddress, ushort numberOfInputs)
            {
                return this.ReadInputs(startAddress, numberOfInputs);
            }
            void CoilWriter.WriteSingle(ushort address, bool value)
            {
                this.WriteSingleCoil(address, value);
            }
            void CoilWriter.WriteMultiple(ushort startAddress, bool[] values)
            {
                this.WriteMultipleCoils(startAddress, values);
            }
            void HoldingRegisterWriter.WriteSingle(ushort address, ushort value)
            {
                this.WriteSingleHoldingRegister(address, value);
            }
            void HoldingRegisterWriter.WriteMultiple(ushort startAddress, ushort[] values)
            {
                this.WriteMultipleHoldingRegisters(startAddress, values);
            }
            private readonly Func<NModbusDeviceConnection> newDeviceConnection;
        }
    }
